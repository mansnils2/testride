import * as React from 'react';

export class Layout extends React.Component<{}, {}> {
    render() {
        return <div className="h-100">
            {this.props.children}
        </div>;
    }
}
