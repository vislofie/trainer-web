import { motion } from 'framer-motion';
import { useEffect, useState } from 'react';
import TextField from '../../TextField/TextField'
import './AddExercisePopup.css'
import { debounce } from 'lodash';
import React from 'react';
import uploadIcon from "../../../assets/icons/personal cabient/upload.svg"
import { useRef } from 'react';
import { Exercise, ExerciseLevel, MuscleGroup } from '../../../models/Exercise';
import { ExerciseUpload } from '../../../models/Exercise';
import { addExercise, getExerciseLevels, getMuscleGroups, updateExercise } from '../../../services/ExerciseService';
import * as Yup from "yup"
import { yupResolver } from '@hookform/resolvers/yup';
import { useForm } from 'react-hook-form';
import { getFileUrl } from '../../../services/FileService';

interface Props {
    onClose : () => void;
    loadedExercise?: Exercise;
}

const AddExercisePopup = ({onClose, loadedExercise}: Props) => {
  type ExerciseAddFormInputs = {
    exerciseName: string;
    exerciseDescription: string;
    hasMuscleGroups: boolean;
    imagePresent: boolean;
    videoPresent: boolean;
  }
  
  const validation = Yup.object().shape({
    exerciseName: Yup.string().min(4, "Name is supposed to be at least 4 symbols!").required("Name is required!"),
    exerciseDescription: Yup.string().min(12, "Instruction supposed to be at least 12 symbols!").required("Instructions are required!"),
    hasMuscleGroups: Yup.boolean().default(false).oneOf([true], "You need to have at least 1 muscle group!"),
    imagePresent: Yup.boolean().default(false).oneOf([true], "Picture is required!"),
    videoPresent: Yup.boolean().default(false).oneOf([true], "Video is required!")
  });

  const { register, handleSubmit, formState: { errors }, setValue, trigger} = useForm<ExerciseAddFormInputs>({
    resolver: yupResolver(validation),
    mode: 'onChange'
  });

  const [exerciseTitle, setExerciseTitle] = useState<string>('');
  const [exerciseDescription, setExerciseDescription] = useState<string>('');

  const [muscleValue, setMuscleValue] = useState<string>('');
  const [muscleGroups, setMuscleGroups] = useState<MuscleGroup[]>([]);
  const [filteredMuscleGroups, setFilteredMuscleGroups] = useState<MuscleGroup[]>([])
  const [selectedMuscleGroups, setSelectedMuscleGroups] = useState<MuscleGroup[]>([])

  const [uploading, setUploading] = useState<boolean>(false);
  
  const [key, setKey] = useState(0);

  const [height, setHeight] = useState(0);
  const [selectedMuscleLevel, setSelectedMuscleLevel] = useState(0);

  const [selectedPicture, setSelectedPicture] = useState<File | undefined>(undefined);
  const [selectedPicturePreview, setSelectedPicturePreview] = useState<string | undefined>(undefined);

  const [selectedVideo, setSelectedVideo] = useState<File | undefined>(undefined);
  const [selectedVideoPreview, setSelectedVideoPreview] = useState<string | undefined>(undefined);

  const [exerciseLevels, setExerciseLevels] = useState<ExerciseLevel[]>([]);

  const uploadImageRef = useRef<HTMLInputElement>(null);
  const uploadVideoRef = useRef<HTMLInputElement>(null);
  const suggestionRef = React.createRef<HTMLDivElement>();

  const handleImageUploadClick = () => {
    uploadImageRef.current?.click();
  };

  const handleVideoUploadClick = () => {
    uploadVideoRef.current?.click();
  };

  const handleMuscleAddClick = (mg: string): void => {
    setTimeout(() => {
      setKey(prevKey => prevKey + 1);
      setFilteredMuscleGroups([]);
      setMuscleValue('');
      setHeight(0);
    }, 0);

    const muscleGroup = filteredMuscleGroups.find(mgr => mgr.name == mg)!;
    
    setSelectedMuscleGroups(prevGroups => [...prevGroups, muscleGroup]);
    setValue('hasMuscleGroups', true);
    trigger('hasMuscleGroups');
  }

  const handleMuscleRemoveClick = (mg: string): void => {
    setTimeout(() => {
      if (muscleValue !== '') {
        const muscleGroup = selectedMuscleGroups.find(mgr => mgr.name == mg)!;
        setFilteredMuscleGroups(prevGroups => [...prevGroups, muscleGroup]);
      }

      setKey(prevKey => prevKey + 1);
      setHeight(suggestionRef?.current?.scrollHeight ?? 0);
    }, 0);

    setSelectedMuscleGroups(prevGroups => prevGroups.filter(prevMg => prevMg.name.toLowerCase() !== mg.toLowerCase()));
    if (selectedMuscleGroups.length == 1) {
      setValue('hasMuscleGroups', false);
      trigger('hasMuscleGroups');
    }
  }

  const handleMuscleChange = debounce((event: React.ChangeEvent<HTMLInputElement>): void => {
    const value = event.target.value;
    if (!value) {
      setFilteredMuscleGroups([]);
      return;
    }

    console.log(muscleGroups
      .filter(mg => selectedMuscleGroups.includes(mg)));

    setTimeout(() => {
      setFilteredMuscleGroups(
        muscleGroups
        .filter(mg => mg.name.toLowerCase().startsWith(value.toLowerCase()))
      );
  
      setKey(prevKey => prevKey + 1);
      setHeight(suggestionRef?.current?.scrollHeight ?? 0);
    }, 0);
  }, 0);


  useEffect(() => {
    if (!selectedPicture) {
      setSelectedPicturePreview(undefined);
      return;
    }

    const objectUrl = URL.createObjectURL(selectedPicture);
    setSelectedPicturePreview(objectUrl);

    return () => URL.revokeObjectURL(objectUrl);
  }, [selectedPicture])

  useEffect(() => {
    if (!selectedVideo) {
      setSelectedVideoPreview(undefined);
      return;
    }

    const objectUrl = URL.createObjectURL(selectedVideo);
    setSelectedVideoPreview(objectUrl);

    return () => URL.revokeObjectURL(objectUrl);
  }, [selectedVideo])

  useEffect(() => {
    const dataInit = async() => {
      const levels = await getExerciseLevels();
      if (!levels) {
        return;
      }

      setExerciseLevels(levels);

      await muscleGroupsInit();
      await loadExerciseData(levels!);
    }
    const muscleGroupsInit = async() => {
      const muscleGroups = await getMuscleGroups();
      if (muscleGroups) {
        setMuscleGroups(muscleGroups);
      }
    }

    const loadExerciseData = async(levels: ExerciseLevel[]) => {
      if (loadedExercise) {
        setExerciseTitle(loadedExercise.title);
        setExerciseDescription(loadedExercise.description);
        setSelectedMuscleLevel(levels.findIndex(el => el.name === loadedExercise.exerciseLevel.name));
        setSelectedMuscleGroups(loadedExercise.muscleGroups);
  
        setSelectedPicturePreview(await getFileUrl(loadedExercise.pictureId));
        setSelectedVideoPreview(await getFileUrl(loadedExercise.videoId));

        setValue("exerciseName", loadedExercise.title);
        setValue("exerciseDescription", loadedExercise.description);
        setValue("hasMuscleGroups", true);
        setValue("imagePresent", true);
        setValue("videoPresent", true);
        trigger();
      }
    }

    dataInit();
  }, [])


  const handleSelectPicture = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (!event.target.files || event.target.files.length === 0) {
      setValue('imagePresent', false);
      setSelectedPicture(undefined);
      trigger('imagePresent');
      return;
    }

    if (event.target.files[0].size > 30_000_000)
    {
      alert('File is bigger than 30 MB! Select a smaller file.');
      return;
    }

    setValue('imagePresent', true);
    setSelectedPicture(event.target.files[0]);
    trigger('imagePresent');
  }

  const handleSelectVideo = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (!event.target.files || event.target.files.length === 0) {
      setValue('videoPresent', false);
      setSelectedVideo(undefined);
      trigger('videoPresent');
      return;
    }

    if (event.target.files[0].size > 30_000_000)
    {
      alert('File is bigger than 30 MB! Select a smaller file.');
      return;
    }

    setValue('videoPresent', true);
    setSelectedVideo(event.target.files[0]);
    trigger('videoPresent');
  }

  const handleExerciseAdd = () => {
    const exerciseCreate = async () => {
      const exercise: ExerciseUpload = {
        title: exerciseTitle,
        description: exerciseDescription,
        picture: selectedPicture!,
        video: selectedVideo!,
        exerciseLevelId: exerciseLevels[selectedMuscleLevel].id,
        muscleGroupIds: selectedMuscleGroups.map(mg => mg.id)
      }

      

      await addExercise(exercise);
      onClose();
    }

    const exerciseUpdate = async () => {
      const exerciseNew: ExerciseUpload = {
        title: undefined,
        description: undefined,
        picture: undefined,
        video: undefined,
        exerciseLevelId: undefined,
        muscleGroupIds: undefined
      };
      
      if (loadedExercise?.title != exerciseTitle) {
        exerciseNew.title = exerciseTitle;
      }
      if (loadedExercise?.description != exerciseDescription) {
        exerciseNew.description = exerciseDescription;
      }
      if (selectedPicture !== undefined) {
        exerciseNew.picture = selectedPicture;
      }
      if (selectedVideo !== undefined) {
        exerciseNew.video = selectedVideo;
      }
      if (loadedExercise?.exerciseLevel.name !== exerciseLevels[selectedMuscleLevel].name) {
        exerciseNew.exerciseLevelId = exerciseLevels[selectedMuscleLevel].id;
      }
      if (loadedExercise?.muscleGroups !== selectedMuscleGroups) {
        exerciseNew.muscleGroupIds = selectedMuscleGroups.map(mg => mg.id);
      }

      console.log(exerciseNew);

      await updateExercise(loadedExercise?.id!, exerciseNew);
      onClose();
    }

    if (!loadedExercise) {
      exerciseCreate();
    }
    else {
      exerciseUpdate();
    }
  }

  return (
    <div className="popup-overlay">
      <form className="popup-container" onSubmit={handleSubmit(handleExerciseAdd)}>
        <h1>Add exercise</h1>
          <div className="text-fields">
            <TextField inputType='text' placeholder='Exercise name' {...register('exerciseName')} value={exerciseTitle} onChange={(e: React.ChangeEvent<HTMLInputElement>) => {setExerciseTitle(e.target.value); }}/>
            {errors.exerciseName && <p className="error">{errors.exerciseName.message}</p>}
            <TextField inputType='text' placeHolder='Exercise instructions' {...register('exerciseDescription')} value={exerciseDescription} onChange={(e:React.ChangeEvent<HTMLInputElement>) => {setExerciseDescription(e.target.value); }}/>
            {errors.exerciseDescription && <p className="error">{errors.exerciseDescription.message}</p>}
            <TextField inputType='text' placeholder='Muscle groups' onChange={(e: React.ChangeEvent<HTMLInputElement>) => { handleMuscleChange(e); setMuscleValue(e.target.value)}} value={muscleValue}/>
            {filteredMuscleGroups.length > 0 && (
              <motion.div 
                    className='suggestion-panel'
                    initial={{ height: height }}
                    animate={{ height: filteredMuscleGroups.length > 0 ? 'auto' : 0 }}
                    transition={{ type: 'spring', stiffness: 400, damping: 50 }}
                    key={key}
                    ref={suggestionRef}>
                    {filteredMuscleGroups.map((group, index) => (
                  <p key={index} style={{cursor: 'pointer'}} onClick={() => handleMuscleAddClick(group.name)}>{group.name}</p>
                ))}
              </motion.div>
            )}
            {errors.hasMuscleGroups && <p className='error'>{errors.hasMuscleGroups.message}</p>}
            {selectedMuscleGroups.length > 0 && (
              <div className="selected-muscle-groups">
                {selectedMuscleGroups.map((group, index) => (
                  <p key={index} style={{cursor: 'pointer'}} onClick={() => handleMuscleRemoveClick(group.name)}>{group.name}</p>
                ))}
              </div>
            )}

            <div className="level-exercises">
              {exerciseLevels.map((exerciseLevel, index) => (
                <p className={index === selectedMuscleLevel ? 'selected' : ''} key={index} style={{cursor: 'pointer'}} onClick={() => { setSelectedMuscleLevel(index); }}>{exerciseLevel.name}</p>
              ))}
            </div>

            <div className="image-preview">
              <img src={selectedPicturePreview}/>
            </div>

            <label htmlFor='exericse-media' className='exercise-media-label'>
              <button onClick={handleImageUploadClick} type='button'>
                <p>Upload image of the exercise</p>
                <img src={uploadIcon}></img>
              </button>
            </label>
            <input  type="file" 
                    accept=".jpg,.png,.webp,.jpeg"
                    name='exercise-picture' 
                    className='exercise-media-upload' 
                    ref={uploadImageRef} 
                    onChange={handleSelectPicture}/>
            {errors.imagePresent && <p className='error'>{errors.imagePresent.message}</p>}
            <div className="video-preview">
                <video src={selectedVideoPreview} controls/>
            </div>

            <label htmlFor='exercise-media' className='exercise-media-label'>
              <button onClick={handleVideoUploadClick} type='button'>
                <p>Upload video of the exercise</p>
                <img src={uploadIcon}></img>
              </button>
            </label>
            <input  type="file" 
                    accept=".mp4, .webm, .mov"
                    name='exercise-video' 
                    className='exercise-media-upload' 
                    ref={uploadVideoRef}
                    onChange={handleSelectVideo}/>
            {errors.videoPresent && <p className='error'>{errors.videoPresent.message}</p>}

            {loadedExercise ? 
            (
              <button className='add-exercise' type='submit' disabled={uploading}>
                Update exercise
              </button>
            )
            :
            (
              <button className='add-exercise' type='submit' disabled={uploading}>
                Add exercise
              </button>
            )
          }
            
          </div>

          
      </form>
      <div className="popup-click-container" style={{cursor: 'pointer'}} onClick={(e) => { if (!uploading) onClose()}}/>
    </div>
  )
}

export default AddExercisePopup
