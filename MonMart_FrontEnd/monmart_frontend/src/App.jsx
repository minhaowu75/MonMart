import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { Nav, PrivateRoute } from '_components';
import { history } from '_utilities';
import { HomePage } from 'homePage';
import { LoginPage } from 'loginPage';

export { App };

function App() {
  return (
    <div className="app-container bg-light">
    <Router history={history}>
        <Nav />
        <div className="container pt-4 pb-4">
            <Switch>
                <PrivateRoute exact path="/" component={HomePage} />
                <Route path="/login" component={LoginPage} />
                <Redirect from="*" to="/" />
          </Switch>
        </div>
      </Router>
    </div>
  );
}