import * as React from 'react';

export class Layout extends React.Component<{}, {}> {
    render() {
        return <div className="container-fluid">
            <div className="col-md-12">
                {this.props.children}
            </div>
        </div>;
    }
}
