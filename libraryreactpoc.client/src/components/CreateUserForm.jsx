import { useState } from "react";
import './Styles.css';
import CreateUserFormButton from "./CreateUserFormButton";

function CreateUserForm() {

    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [submitted, setSubmitted] = useState(false);
    const [error, setError] = useState(false);

    const handleName = (e) => {
        setName(e.target.value);
        setSubmitted(false);
    }

    const handleEmail = (e) => {
        setEmail(e.target.value);
        setSubmitted(false);
    }

    const handlePassword = (e) => {
        setPassword(e.target.value);
        setSubmitted(false);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        if (name === '' || email === '' || password === '') {
            setError(true);
        }
        else {

            setSubmitted(true);
            setError(false);
        }
    }

    const successMessage = () => {
        return (
            <div className="success" style={{ display: submitted ? '' : 'none', }}>
                <h1>User {name} successfully registered!</h1>
            </div>
        );
    }

    const errorMessage = () => {
        return (
            <div className="error" style={{ display: error ? '' : 'none', }}>
                <h1>Please enter all fields</h1>
            </div>
        );
    }

    return (
        <div className="form">
            <div>
                <h1>User Registration</h1>
            </div>
            <div className="messages">
                {errorMessage()}
                {successMessage()}
            </div>
            <form>
                <CreateUserFormButton label="Name" onChange={handleName} />
                <CreateUserFormButton label="Email" onChange={handleEmail} />
                <CreateUserFormButton label="Password" onChange={handlePassword} />
                <div id="createUserFormSubmitButton">
                    <button onClick={handleSubmit} className="btn" type="submit">
                        Submit
                    </button>
                </div>
            </form>
        </div>
    );
}

export default CreateUserForm;