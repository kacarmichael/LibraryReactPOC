import { useEffect, useState } from 'react';
import './App.css';
import './components/UserTable';
import './components/CreateUserForm';
import UserTable from './components/UserTable';
import CreateUserForm from './components/CreateUserForm';

function App() {
    const [users, setUsers] = useState();
    const [selectedTab, setSelectedTab] = useState("left");

    useEffect(() => {
        populateUsers();
    }, []);

    function renderDisplay(selectionState) {
        switch (selectionState) {
            case "left": return <UserTable users={users}/>;
            case "middle": return <CreateUserForm/>;
            default: return <label>Default component</label>;
        }
    }


    return (
        <div>
            <div className='e-btn-group'>
                <input type="radio" id="radioleft" name="align" value="left" checked={selectedTab === "left"} onChange={e => setSelectedTab(e.target.value)} />
                <label className="e-btn" htmlFor="radioleft">All Users</label>
                <input type="radio" id="radiomiddle" name="align" value="middle" checked={selectedTab === "middle"} onChange={e => setSelectedTab(e.target.value)} />
                <label className="e-btn" htmlFor="radiomiddle">Create User</label>
            </div>
            <div className='content'>
                {renderDisplay(selectedTab)}
            </div>
        </div>
    );
    
    async function populateUsers() {
        const response = await fetch('https://localhost:7285/api/users');
        const data = await response.json();
        setUsers(data);
    }
}

export default App;