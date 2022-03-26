import "../styles/globals.css";
import type { AppProps } from "next/app";
import Head from "next/head";

function MyApp({ Component, pageProps }: AppProps) {
	return (
		<>
			<Head>
				<title>Long Rocks - Solar Panel Quoting System</title>
				<meta
					property='description'
					content='Get solar panel quotes, fast and free.'
				/>
				<link rel='icon' href='/logo.svg' type='image/svg+xml'></link>
				<meta property='og:title' content='Long Rocks' />
				<meta property='og:image' content='solar-panel-house.jpg' />
			</Head>
			<Component {...pageProps} />
		</>
	);
}

export default MyApp;
