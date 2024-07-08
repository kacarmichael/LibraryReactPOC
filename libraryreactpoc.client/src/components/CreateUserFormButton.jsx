function CreateUserFormButton({ label, onChange }) {
  return (
      <div id="createUserFormButton">
          <label className="label">{label}</label>
          <input onChange={onChange} className="input" value={label} type={(label === 'Password') ? "password" : "text"} />
      </div> 
  );
}

export default CreateUserFormButton;