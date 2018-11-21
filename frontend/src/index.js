import React from 'react';
import { render } from 'react-dom';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './index.css';

import App from './App';
import Cliente from './componentes/Cliente';
import NotFound from './componentes/NotFound';
import Producto from './componentes/Producto';

const Root = () => {
	return (
		<Router basename="/app">
			<Switch>
				<Route exact path="/" component={App} />
                <Route exact path="/cliente" component={Cliente} />
				<Route exact path="/producto" component={Producto} />
				<Route component={NotFound} />
			</Switch>
		</Router>
	)
}
//ReactDOM.render(<App />, document.getElementById('root'));
render(<Root/>, document.querySelector('#root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA

//serviceWorker.unregister();