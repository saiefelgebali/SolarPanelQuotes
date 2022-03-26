import React from "react";
import { EstimatedQuote } from "../interface/api.interface";

const QuotePreview: React.FC<{ quote: EstimatedQuote }> = ({ quote }) => {
	return (
		<div className='rounded border p-8 grid md:grid-cols-2 gap-4'>
			<div className='flex flex-col'>
				<h2 className='text-lg font-bold mb-4 md:mb-0'>
					{quote.panels.panel.model}
				</h2>
				<p className='text-gray-500'>
					<strong>{quote.panels.count}</strong> panels
				</p>
				<p className='text-gray-500'>
					<strong>{Math.round(quote.panels.totalPower)}</strong> Watts
				</p>
			</div>
			<div className='flex flex-col gap-2'>
				<p className='text-gray-500'>
					<span className='text-xl'>
						£{quote.totalPrice.toFixed(2)}
					</span>{" "}
					Upfront
				</p>
				{quote.averageDailyProfit > 0 && (
					<p className='text-green-700'>
						<span className='text-xl'>
							£{quote.averageDailyProfit.toFixed(2)}
						</span>{" "}
						profit per day
					</p>
				)}
				{quote.averageDailyProfit > 0 && (
					<p className='text-gray-500'>
						<span className='text-xl'>
							{Math.ceil(quote.daysToBreakEven)}
						</span>{" "}
						days to break even
					</p>
				)}
			</div>
			<a className='font-semibold text-gray-900 cursor-pointer'>
				View more
			</a>
		</div>
	);
};

export default QuotePreview;
