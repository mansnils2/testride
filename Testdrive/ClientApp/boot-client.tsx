import './css/site.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'react-router-redux';
import { createBrowserHistory } from 'history';
import configureStore from './configureStore';
import { IApplicationState } from './store';
import * as RoutesModule from './routes';
let routes = RoutesModule.routes;
import { PersistGate } from 'redux-persist/integration/react';
import Spinner from './Components/Shared/Spinner';
import { setPusherClient } from 'react-pusher';
import Pusher from 'pusher-js';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = (window as any).initialReduxState as IApplicationState;
const store = configureStore(history, initialState);

function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing configuration
    // and injects the app into a DOM element.
	fetch('credentials/pusher', { credentials: 'include' })
		.then(response => response.json())
		.then(data => {
			const pusherClient = new Pusher(data.key,
				{
					cluster: data.cluster,
					encrypted: true
				});

			setPusherClient(pusherClient);
		})
		.catch();

    ReactDOM.render(
        <AppContainer>
            <Provider store={store.store}>
                <PersistGate loading={<Spinner />} persistor={store.persistor}>
                    <ConnectedRouter history={history} children={routes} />
                </PersistGate>
            </Provider>
        </AppContainer>,
        document.getElementById('react-app')
    );
}

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept('./routes', () => {
        routes = require<typeof RoutesModule>('./routes').routes;
        renderApp();
    });
}