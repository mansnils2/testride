import { Reducer, Action } from 'redux';
import { IAppThunkAction } from '../.';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface INavbarState {
	open?: boolean;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface IToggleNavbarAction { state: INavbarState, type: 'TOGGLE_NAVBAR' }

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = IToggleNavbarAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
	toggle: (): IAppThunkAction<KnownAction> => (dispatch, getState) => {
		dispatch({ state: getState().navbar, type: 'TOGGLE_NAVBAR' });
	}
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<INavbarState> = (state: INavbarState, incomingAction: Action) => {
	const action = incomingAction as KnownAction;
	switch (action.type) {
		case 'TOGGLE_NAVBAR':
			const next = !state.open;
			return { open: next };
		default:
			// For unrecognized actions (or in cases where actions have no effect), must return the existing state
			//  (or default initial state if none was supplied)
			return state === undefined ? { open: false } : state;
	}
};