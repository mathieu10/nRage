nRage
===========

A simple .NET wrapper for the TVRage.com API.

History
-------

###v0.2 (2012-Dec-17)
+ Support update/scheduling API

###v0.1 (2012-Dec-15)
+ Initial official release

Roadmap
-------

###v0.3
+ Common data model abstraction

###v0.4
+ Basic local cache 

###v1.0
+ Intelligent configurable local cache
+ nRage documenation
+ TVRage API documentation 

###Very low priority
+ TV schedule API

TVRage API notes
================

Observed inconsistencies
------------------------

* <ended> sometimes returns either empty/self-terminating or "0"s
* <AKAs> not returned at all if empty; other tags are returned as self-terminating nodes
* API guide indicates EpisodeInfo is retrieved by:

    > http://services.tvrage.com/feeds/episodeinfo.php?show={SHOWNAME}&exact=1&ep={SEASON}x{EPISODE}

  Actual usage is:

    > http://services.tvrage.com/feeds/episodeinfo.php?sid={SHOWID}&ep={SEASON}x{EPISODE}

* LastUpdates does not appear to support the advertised ability to get updates from a specific point in time
* Inconsistent naming (eg sometimes "id" or "name" othertimes "showid" or "showname")
* Inconsistent casing (eg XML for show info opens with "Showinfo" - all other nodes in show info are strict lower case)
* Inconsistent number format (eg: episode number example is 2x05 - leading zero for episode number, no leading zero for season - but both work interchangeably)

TODO / Notes to self
--------------------

* Support country attribute for <network> nodes
* Finish in-line XML documentation for contracts
* Proper API documentation (eg: status codes for show list)
* Re-think Stream usage for IRetriever (poor memory management)