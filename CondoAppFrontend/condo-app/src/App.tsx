import React from 'react';
import Login from './pages/Login';
import { Route, Switch } from 'react-router-dom';
import Home from './pages/Home';
import Reservas from './pages/Reservas';

function App() {
  return (
      <Switch>
        <Route path='/' exact>
          <Home />
        </Route>
        <Route path='/login' exact>
          <Login />
        </Route> 
        <Route path='/reservas' exact>
          <Reservas />
        </Route>
        <Route path='*'>
          <p>Tela não encontrada</p>
        </Route>
      </Switch>
  );
}

export default App;
