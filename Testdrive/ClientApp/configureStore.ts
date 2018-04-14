import { createStore, applyMiddleware, compose, combineReducers, GenericStoreEnhancer, Store, StoreEnhancerStoreCreator, ReducersMapObject } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as StoreModule from './store';
import { IApplicationState, reducers } from './store';
import { History } from 'history';
import { persistStore, persistReducer, BaseReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';

export default function configureStore(history: History, initialState?: IApplicationState) {
    // Build middleware. These are functions that can process the actions before they reach the store.
    const windowIfDefined = typeof window === 'undefined' ? null : window as any;
    // If devTools is installed, connect to it
    const devToolsExtension = windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__ as () => GenericStoreEnhancer;
    const createStoreWithMiddleware = compose(
        applyMiddleware(thunk, routerMiddleware(history)),
        devToolsExtension ? devToolsExtension() : <TS>(next: StoreEnhancerStoreCreator<TS>) => next
    )(createStore);

    const persistConfig = {
        key: 'root',
        storage
    }

    // Combine all reducers and instantiate the app-wide store instance
    const build = buildRootReducer(reducers) as BaseReducer<any, any>;
    const persistedReducer = persistReducer(persistConfig, build);

    const store = createStoreWithMiddleware(persistedReducer, initialState) as Store<IApplicationState>;

    // Enable Webpack hot module replacement for reducers
    if (module.hot) {
        module.hot.accept('./store', () => {
            const nextRootReducer = require<typeof StoreModule>('./store');
            store.replaceReducer(buildRootReducer(nextRootReducer.reducers));
        });
    }

    const persistor = persistStore(store);
    return { persistor, store };
}

function buildRootReducer(allReducers: ReducersMapObject) {
    return combineReducers<IApplicationState>(Object.assign({}, allReducers, { routing: routerReducer }));
}