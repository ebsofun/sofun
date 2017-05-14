# sofun

Instructions:

	1. Download and install VisualStudio 2017 Community (if necessary)
	1. Install SpecFlow for VisualStudio for 2017 (other versions available for other VS)
		1. Open VisualStudio 
		1. Go to Tools >> Extensions and Updates >> Online (left menu) >> type 'SpecFlow' in search bar to find, then install
	1. Probably best to close and re-open VS
	1. Clone repo from GitHub
	1. Open SoFun.sln in VisualStudio
	1. Update value in App.config with your TMDB api key
		1. <add key="API.Key" value="" />
	1. Build solution (packages should download and install)
	1. Tests should be listed in Test Explorer
		1. If window not open, go to Test >> Windows >> Test Explorer
	1. In Test Explorer window, click Run All
		1. 3 tests should pass
		1. 8 tests should be skipped