import * as React from 'react';
import Greeting from './Greeting';

type TableInfo = {
	name?: string,
	rows: RowInfo[];
}

export const Table = (props: TableInfo) => {
	return props.rows.length > 0 ? <div id={props.name} className="row">
		<div className="w-100 table-holder">
			<table className="table table-hover">
				<thead className="bg-light text-dark">
					<tr>{props.rows[0].items.map(item => <th key={item.description}>{item.description}</th>)}</tr>
				</thead>
				<tbody>
					{props.rows.map(row => <TableRow key={row.key} items={row.items} />)}
				</tbody>
			</table>
		</div>
	</div> : <Greeting title={'Finns inga resultat att visa'} text={'Det finns inga resultat som matchar dina söktermer'} />;
}

// Component and props for each row
type RowInfo = {
	key: string | number,
	items: ItemInfo[];
}

export const TableRow =
	(props: RowInfo) => <tr>{props.items.map(
		item => <TableItem key={item.key} description={item.description} value={item.value} />)}</tr>;

// Component and props for each item in a table-row
type ItemInfo = {
	key: string,
	description: string,
	value: string | JSX.Element | number;
}

export const TableItem = (props: ItemInfo) => <td data-label={props.description}>{props.value}</td>;