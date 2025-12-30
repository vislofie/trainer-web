import searchIcon from '../../../assets/icons/personal cabient/search.svg'
import './BigSearchablePanel.css'

interface Props {
    onSearch: (searchText: string) => void;
    
    firstSectionContent: React.ReactNode;
    secondSectionContent: React.ReactNode;
    
    button0Clicked?: () => void;
    button0Text: string;
    button0Selected: boolean;
    button1Clicked?: () => void;
    button1Text: string;
    button1Selected: boolean;
    button2Clicked?: () => void;
    button2Text: string;
    button2Selected: boolean;
    button3Clicked?: () => void;
    button3Text: string;
    button3Selected: boolean;
}

const BigSearchablePanel = (props: Props) => {
    const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
        props.onSearch(e.target.value.toLowerCase());
    }
    
    return (
        <>
        <div className="bigpanel-container">
            <div className="search-container">
                <div className="searchbar">
                    <input type="text" placeholder="Search for exercises" onChange={handleSearch}/>
                    <img src={searchIcon} style={{cursor: 'pointer'}}/>
                </div>
                <div className="search-container-underline"/>
            </div>

            <div className="bigpanel-menu">
                <div className="button-row">
                    <div className="left-buttons">
                        <button onClick={props.button0Clicked} className={props.button0Selected ? '' : 'selected'}>
                            {props.button0Text}
                        </button>
                        <button onClick={props.button1Clicked} className={props.button1Selected ? '' : 'selected'}>
                            {props.button1Text}
                        </button>
                    </div>
                    <div className="right-buttons">
                        <button onClick={props.button2Clicked} className={props.button2Selected ? '' : 'selected'}>
                            {props.button2Text}
                        </button>
                        <button onClick={props.button3Clicked} className={props.button3Selected ? '' : 'selected'}>
                            {props.button3Text}
                        </button>
                    </div>
                </div>
                
                <div className="bigpanel-list">
                    {props.firstSectionContent}
                    {props.secondSectionContent}
                </div>
            </div>
            
        </div>
        </>
    )
}

export default BigSearchablePanel