import './Checkbox.css'

type Props = {
    label: string
}

const Checkbox = ({label}: Props) => {
  return (
    <>
    <label className="form-control">
        <input type="checkbox" name="checkbox" defaultChecked/>
        {label}
    </label>
    </>
    
    
  )
}

export default Checkbox