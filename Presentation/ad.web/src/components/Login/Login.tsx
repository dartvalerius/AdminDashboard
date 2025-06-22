import { useState } from 'react';
import './index.scss';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { authentication } from '../../redux/action-creators';

export const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigation = useNavigate();
    const dispatch = useDispatch();
    return (
        <div className="login-container">
            <form 
                className="login-form"
                name="Login" 
                onSubmit={(e) => {
                e.preventDefault();
                dispatch(authentication({email: email, password: password}));
                if(localStorage.getItem('token')) {
                    navigation('/dashboard');
                }
                }}
            >
                <h2 className="login-title">Login</h2>
                <div className="form-group">
                <input 
                    type='email' 
                    placeholder='Email address' 
                    value={email} 
                    onChange={(e) => setEmail(e.target.value)}
                    className="form-input"
                />
                </div>
                <div className="form-group">
                <input 
                    type='password' 
                    placeholder='Password' 
                    value={password} 
                    onChange={(e) => setPassword(e.target.value)}
                    className="form-input"
                />
                </div>
                <button type="submit" className="submit-button">Sign In</button>
            </form>
        </div>
    )
}