import {useState} from "react";
import "./Register.css"

function Register(){
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [username, setUsername] = useState('');

    function handleSubmit(){
        console.log(email, password, username)
    }

    return (
        <div className="register">
            <h1 className="title">MojeKino</h1>
            <form className="register-form" onSubmit={handleSubmit}>
                <div className="name">
                    <h2>Rejestracja</h2>
                </div>
                <div className="register-input">
                    <div className="input">
                        <label>E-mail</label>
                        <input value={email} onChange={(event) => setEmail(event.target.value)} type="email"
                               name="email"/>
                    </div>
                    <div className="input">
                        <label className="label">Nazwa użytkownika</label>
                        <input value={username} onChange={(event) => setUsername(event.target.value)} type="text"
                               name="login"/>
                    </div>
                    <div className="input">
                        <label className="label">Hasło</label>
                        <input value={password} onChange={(event) => setPassword(event.target.value)} type="password"
                               name="password"/>
                    </div>
                </div>
                <div className="register-bottom">
                    <button type="submit">Zarejestruj się</button>
                    <a href="#">Masz już konto? Zaloguj się!</a>
                </div>
            </form>
        </div>
    )
}

export default Register;