nRage
===========

A simple .NET wrapper for the TVRage.com API.

TVRage API notes
================
TODO / Notes to self
--------------------
* Support country attribute for <network> nodes
* Finish in-line XML documentation for contracts

Observed inconsistencies
------------------------
* <ended> sometimes returns either empty/self-terminating or "0"s
* <AKAs> not returned at all if empty; other tags are returned as self-terminating nodes