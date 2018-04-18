import * as React from 'react';
import Greeting from './../Shared/Greeting';
import Spinner from './../Shared/Spinner';
import { Table } from './../Shared/Table';
import graphCall from '../../functions/GraphCall';
import { RouteComponentProps } from 'react-router-dom';
import Pusher from 'react-pusher';

export class CustomerDashboard extends React.Component<RouteComponentProps<{}>, { hasError: boolean, isLoading: boolean, customers: any[] }> {
	constructor() {
		super();
		this.state = {
			hasError: false,
			isLoading: true,
			customers: []
		};

		this.addIncomingCustomer = this.addIncomingCustomer.bind(this);
	}

	componentDidMount() {
		const body = {
			query: 
				`{
					customers(include: "Testdrives") {
						id
						name
						socialSecurityNumber
						countOfTestdrives
					}
				}`
		};
		graphCall(
			body,
			(result) => this.setState({ customers: result.data.customers, isLoading: false }),
			() => this.setState({ hasError: true, isLoading: false }));
	}

	render() {
		return this.state.isLoading ? <Spinner message="Hämtar kunder" /> : this.startTestdriveRender();
	}

	startTestdriveRender() {
		return this.state.hasError ? <Greeting title="Det uppstod ett fel" text="Det uppstod tyvärr ett fel medan kunderna sammanställdes." /> : this.renderCustomers();
	}

	addIncomingCustomer(data) {
		const customers = this.state.customers;
		customers.unshift(data);
		this.setState({ customers: customers });
	}

	renderCustomers() {
		const customers = this.state.customers.map((customer) => customer = {
			key: customer.id,
			items:
				[
					{
						key: `name-${customer.id}`,
						description: 'Namn',
						value: customer.name
					},
					{
						key: `customer-${customer.id}`,
						description: 'Perssonnummer',
						value: customer.socialSecurityNumber
					},
					{
						key: `timestamp-${customer.id}`,
						description: 'Provkörningar',
						value: customer.countOfTestdrives > 0 ? `Kunden har provkört ${customer.countOfTestdrives} bil${customer.countOfTestdrives === 1 ? '' : 'ar'}` : 'Kunden har inte provkört några bilar'
					}
				]
		});

		return <div>
			<Pusher channel="customers" event="new-customer" onUpdate={this.addIncomingCustomer} />
			<Table rows={customers} />
		</div>;
	}
}