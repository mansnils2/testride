import * as React from 'react';
import * as NavbarStore from '../../store/misc/Navbar';
import { IApplicationState } from '../../store';
import { connect } from 'react-redux';
import Greeting from './../Shared/Greeting';
import Spinner from './../Shared/Spinner';
import graphCall from '../../functions/GraphCall';

type NavbarProps =
    NavbarStore.INavbarState
    & typeof NavbarStore.actionCreators;

class NavigationBar extends React.Component<NavbarProps, { hasError: boolean, isLoading: boolean, links: any[] }> {
    constructor() {
        super();
        this.state = {
            hasError: false,
            isLoading: true,
            links: []
        };
    }

    componentDidMount() {
        const body = {
            query: `{
						myMenuItems {
							id
							order
							icon
							color
							title
							link
						}
					}`
        };
        graphCall(
            body,
            (result) => { console.log(result.data); this.setState({ links: result.data.myMenuItems, isLoading: false })},
            () => this.setState({ hasError: true, isLoading: false }));
    }

    render() {
        return <div id="navbar" className={this.props.open ? 'navbar-open' : ''}>
            <input type="checkbox" id="drawer-toggle" name="drawer-toggle" checked={this.props.open} onChange={this.props.toggle} />
            <label htmlFor="drawer-toggle" id="drawer-toggle-label"></label>
            <header>
            </header>
            <nav id="drawer">
                <div id="drawer-top">
                    <p className="menu-text ml-3 mb-0 text-white text-center">TESTDRIVE</p>
                </div>
                <div id="drawer-items">
                    <div id="drawer-links">
                        {this.state.isLoading ? <Spinner class="mt-5" /> : this.state.hasError ? <Greeting title={'Inga menyval'} text={'Det uppstod ett fel och dina menyval kan inte visas.'} /> : this.renderItems()}
                    </div>
                </div>
            </nav>
        </div>;
    }

    renderItems() {
        return (this.state.links.length > 0
            ? this.state.links.map((link: any) => <div key={`link-${link.id}`} className="list-group mb-2">
                {link.children.length > 0
                    ? <div className="card p-2">
                        <a data-toggle="collapse" data-parent="#accordion" href={`#${link.title.toLowerCase()}`
                        } className="text-dark">
                            <p className="mb-0"><i className={`fa ${link.icon} mr-2`} style={{ color: link.color }
                            } aria-hidden="true"></i>{link.title}</p></a>
                        <div id={`${link.title.toLowerCase()}`} className="collapse">
                            <div className="card-body p-1">
                                {link.children.map(
                                    (child: any) => <a key={`child-${child.id}`} href={child.url
                                    } className="text-muted m-0 d-block">
                                        <span className="mb-0 pl-2"><i className="fa fa-angle-double-right mr-2 text-primary" aria-hidden="true"></i>{
                                            child.title}</span>
                                    </a>)}
                            </div>
                        </div>
                    </div>
                    : <a href={link.url
                    } className="list-group-item list-group-item-action p-2">
                        <p className="mb-0"><i className={`fa ${link.icon} mr-2`} style={{ color: link.color }
                        } aria-hidden="true"></i>{link.title}</p>
                    </a>
                }
            </div>)
            : <Greeting title={'Inga menyval'} text={'Du har för tillfället inga menyval att visa'} />
        );
    }
}
// Wire up the React component to the Redux store
export default connect(
    (state: IApplicationState) => state.navbar, // Selects which state properties are merged into the component's props
    NavbarStore.actionCreators                 // Selects which action creators are merged into the component's props
)(NavigationBar) as typeof NavigationBar;