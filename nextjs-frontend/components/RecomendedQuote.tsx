import React from "react";
import { EstimatedQuote } from "../interface/api.interface";

const RecomendedQuote: React.FC<{ quote: EstimatedQuote }> = ({ quote }) => {
	if (!quote) return null;

	console.log(quote);

	return (
		<div className='rounded border p-8 mb-8 flex flex-col gap-8'>
			<div className='grid md:grid-cols-2 gap-8'>
				<div className='flex flex-col gap-2'>
					<h2 className='text-xl font-bold mb-4 md:mb-0'>
						{quote.panels.panel.model}
					</h2>
					<p className='text-gray-500'>
						<strong>{quote.panels.count}</strong> panels
					</p>
					<p className='text-gray-500'>
						<strong>{Math.round(quote.panels.totalPower)}</strong>{" "}
						Watts
					</p>
					<p className='text-gray-500'>
						Installation by {quote.installer.installer.id}
					</p>
					<p className='text-gray-500'>
						{quote.tariff.tariff.name} tariff
					</p>
				</div>
				<div className='flex flex-col gap-2'>
					<p className='text-gray-500'>
						<span className='text-2xl'>
							£{quote.totalPrice.toFixed(2)}
						</span>{" "}
						Upfront
					</p>
					{quote.averageDailyProfit > 0 && (
						<p className='text-green-700'>
							<span className='text-2xl'>
								£{quote.averageDailyProfit.toFixed(2)}
							</span>{" "}
							profit per day
						</p>
					)}
					{quote.averageDailyProfit > 0 && (
						<p className='text-gray-500'>
							<span className='text-2xl'>
								{Math.ceil(quote.daysToBreakEven)}
							</span>{" "}
							days to break even
						</p>
					)}
				</div>
			</div>
			<a className='font-semibold text-gray-900 cursor-pointer'>
				View more
			</a>
		</div>
	);
};

export default RecomendedQuote;
