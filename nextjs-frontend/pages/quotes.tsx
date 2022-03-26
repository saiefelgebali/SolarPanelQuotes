import { GetServerSideProps, NextPage } from "next";
import { useRouter } from "next/router";
import React, { useEffect, useState } from "react";
import { getQuotes, GetQuotesBody } from "../api/quotes";
import Header from "../components/Header";
import ParamsPreview from "../components/ParamsPreview";
import QuotePreview from "../components/QuotePreview";
import RecomendedQuote from "../components/RecomendedQuote";
import { EstimatedQuote } from "../interface/api.interface";

const Quotes: NextPage<{
	quotes: EstimatedQuote[];
	params: GetQuotesBody;
	redirect: boolean;
}> = ({ quotes, params, redirect }) => {
	const router = useRouter();

	useEffect(() => {
		if (!router.isReady) return;
		// redirect to / if no 'redirect' is set to true
		if (redirect) router.push("/quotes");
	}, [router]);

	return (
		<>
			<Header />
			<div className='container py-8 flex gap-8 flex-col md:flex-row'>
				<aside>{params && <ParamsPreview params={params} />}</aside>
				<main>
					<h1 className='text-2xl font-bold mb-4 px-8'>Our pick</h1>
					{quotes && (
						<>
							<RecomendedQuote quote={quotes[0]} />
							<h1 className='text-2xl font-bold mb-4 px-8'>
								Other options ({quotes.length - 1})
							</h1>
							<div className='grid xl:grid-cols-2 gap-8'>
								{quotes.map(
									(quote, i) =>
										i > 0 && (
											<QuotePreview
												key={i}
												quote={quote}
											/>
										)
								)}
							</div>
						</>
					)}
				</main>
			</div>
		</>
	);
};

export const getServerSideProps: GetServerSideProps = async (ctx) => {
	const params = ctx.query;

	const body = {
		roofLength: params.roofLength as string,
		roofWidth: params.roofWidth as string,
		averageConsumption: params.averageConsumption as string,
		electricityCost: params.electricityCost as string,
		budget: params.budget as string,
	};

	// call API to get quotes
	const quotes = await getQuotes(body);

	// return to / if no quotes are found
	if (!quotes) return { props: { quotes: [], params, redirect: true } };

	// otherwise return the sorted quotes
	const sortedQuotes = quotes.sort((a, b) => {
		return b.averageDailyProfit - a.averageDailyProfit;
	});

	return {
		props: { quotes: sortedQuotes, params, redirect: false },
	};
};

export default Quotes;
