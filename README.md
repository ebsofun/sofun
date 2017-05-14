# sofun

Instructions:

	1. Download and install VisualStudio 2017 Community (if necessary)
	2. Install SpecFlow for VisualStudio for 2017 (other versions available for other VS)
		a. Open VisualStudio 
		b. Go to Tools >> Extensions and Updates >> Online (left menu) >> type 'SpecFlow' in search bar to find, then install
	3. Probably best to close and re-open VS
	4. Clone repo from GitHub
	5. Open SoFun.sln in VisualStudio
	6. Update value in App.config with your TMDB api key
		a. <add key="API.Key" value="" />
	6. Build solution (packages should download and install)
	7. Tests should be listed in Test Explorer
		a. If window not open, go to Test >> Windows >> Test Explorer
	8. In Test Explorer window, click Run All
		a. 3 tests should pass
		b. 8 tests should be skipped