import React from "react";
import { GetQuotesBody } from "../api/quotes";

const ParamsPreview: React.FC<{ params: GetQuotesBody }> = ({ params }) => {
	return (
		<div className='h-max p-8 w-72 flex-shrink-0'>
			<h1 className='text-lg font-bold'>Your House Details</h1>
			<div className='text-gray-500'>
				<p>
					Roof Length: <strong>{params.roofLength}m</strong>
				</p>
				<p>
					Roof Width: <strong>{params.roofWidth}m</strong>
				</p>
				<p>
					Average Consumption:{" "}
					<strong>{params?.averageConsumption}kWh</strong>
				</p>
				<p>
					Electricity Cost:{" "}
					<strong>£{params.electricityCost}/kWh</strong>
				</p>
				<p>
					Budget: <strong>£{params.budget}</strong>
				</p>
			</div>
		</div>
	);
};

export default ParamsPreview;
