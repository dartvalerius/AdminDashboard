import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.scss'
import { Dashboard, Login } from './components';
import { useEffect } from 'react';

function App() {
  useEffect(() => {
    if (!localStorage.getItem('token')) {
      if (window.location.pathname !== '/login')
        window.location.pathname = '/login'
    }
  }, [])
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<Login/>}/>
        <Route path='/dashboard' element={<Dashboard/>}/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
