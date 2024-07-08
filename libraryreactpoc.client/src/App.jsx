import { useEffect, useState } from 'react';
import './App.css';
import './components/UserTable';
import './components/CreateUserForm';
import UserTable from './components/UserTable';
import CreateUserForm from './components/CreateUserForm';
import Header from './components/Header';
import NavBar from './components/NavBar';

function App() {
    const [users, setUsers] = useState();
    const [selectedTab, setSelectedTab] = useState("left");
    const tabs = ["AllUsers", "CreateUser"];

    useEffect(() => {
        populateUsers();
    }, []);

    function renderDisplay(selectionState) {
        switch (selectionState) {
            case "AllUsers": return <UserTable users={users}/>;
            case "CreateUser": return <CreateUserForm/>;
            default: return <label>Default component</label>;
        }
    }

    function handleTabClick(tab) {
        setSelectedTab(tab);
    }

    async function populateUsers() {
        const response = await fetch('https://localhost:7285/api/users');
        const data = await response.json();
        setUsers(data);
    }
    
    return (
        <div>
            <header>
                <Header/>
            </header>
            <NavBar tabs={tabs} onSelection={handleTabClick}></NavBar>
            <div className='content'>
                {renderDisplay(selectedTab)}
                
            </div>
        </div>
    );
    
    
}

export default App;