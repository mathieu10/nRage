nRage
===========

A simple .NET wrapper for the TVRage.com API.

History
-------

--v0.1 (2012-Dec-15)--

Roadmap
-------
--v0.2--
* Support update/scheduling API

--v0.3--
* Commom data model abstraction

--v0.4--
* Basic local cache 

--v1.0--
* Intelligent configurable local cache
* nRage documenation
* TVRage API documentation
* 


TVRage API notes
================

Observed inconsistencies
------------------------
* <ended> sometimes returns either empty/self-terminating or "0"s
* <AKAs> not returned at all if empty; other tags are returned as self-terminating nodes
* API guide indicates EpisodeInfo is retrieved by:
* LastUpdates does not appear to support the advertised ability to get updates from a specific point in time

TODO / Notes to self
--------------------
* Support country attribute for <network> nodes
* Finish in-line XML documentation for contracts
* Proper API documentation (eg: status codes for show list)
* Re-think Stream usage for IRetriever (poor memory management)



	> http://services.tvrage.com/feeds/episodeinfo.php?show={SHOWNAME}&exact=1&ep={SEASON}x{EPISODE}

  Actual usage is:

	> http://services.tvrage.com/feeds/episodeinfo.php?sid={SHOWID}&ep={SEASON}x{EPISODE}

* Inconsistent naming (eg sometimes "id" or "name" othertimes "showid" or "showname")
* Inconsistent casing (eg XML for show info opens with "Showinfo" - all other nodes in show info are strict lower case)
* Inconsistent number format (eg: episode number example is 2x05 - leading zero for episode number, no leading zero for season - but both work interchangeably)