import { useState } from "react";


function NavBar({ tabs, onSelection }) {

    const [selectedTab, setSelectedTab] = useState();

    const onTabChange = (tab) => {
        setSelectedTab(tab);
        onSelection(tab);
    }

    return (
            tabs.map((tab, index) =>
                <div key={index}>
                    <input type="radio" id={`radio${index}`} name="align" value={tab} checked={selectedTab === tab} onChange={() => onTabChange(tab)} />
                    <label className="e-btn" htmlFor={`radio${index}`}>{tab}</label>
                </div>
            ) 
    );
}

export default NavBar;