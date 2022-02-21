import {Home} from './Home';
import {Competitors} from './Competitors';
import {BrowserRouter, Route, Switch, NavLink} from 'react-router-dom';



function App() {
  return (
    <BrowserRouter>
    <div className="App container">
      <h3 className="d-flex justify-content-center m-3">
        TimeKeeper
      </h3>
        
      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className="navbar-nav">
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/home">
              Home
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/competitors">
              Competitors
            </NavLink>
          </li>
        </ul>
      </nav>

      <Switch>
        <Route path='/home' component={Home}/>
        <Route path='/competitors' component={Competitors}/>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;