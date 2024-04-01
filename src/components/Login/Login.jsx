import { useState } from "react";
import "./Login.css"

function Login(){
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    function handleSubmit(){
        console.log(email, password)
    }

    return(
        <div className="login">
            <h1 className="title">Moje Kino</h1>
            <form className="login-form" onSubmit={handleSubmit}>
                <div className="login-input">
                    <div className="input">
                        <label>Email</label>
                        <input value={email} onChange={(event) => setEmail(event.target.value)} type="email" name="email"/>
                    </div>
                    <div className="input">
                        <label>Hasło</label>
                        <input value={password} onChange={(event) => setPassword(event.target.value)} type="password" name="password"/>
                    </div>
                </div>
                <div className="login-bottom">
                    <button type="submit">Zaloguj się</button>
                    <a href="#">Zresetuj hasło</a>
                    <a href="../Register/Register.jsx">Nie masz konta? Zarejestruj się!</a>
                </div>
            </form>
        </div>
    )
}

export default Login;