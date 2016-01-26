# FLUKAToANSYS

This software allows to read the ASCII output of the FLUKA code in order to extract some information
such as the maximum deposited energy over the whole geometry, the most loaded section (z-axis), the integral
of the whole deposited energy, ...

It also creates a new ASCII file that can be read in ANSYS via the TABLE command (APDL snippet) and thus allows
the use of the FLUKA results as an input into an ANSYS thermal simulations.

The original code was developed by CERN developers Donato CAMPANINI and Alessandro DALLOCCHIO.

It was patched in 2014 by CERN developer Paolo GRADASSI.

Finally it was released in 25.01.2016 by CERN (EN/MME-EDS section, Alessandro BERTARELLI) under the 
Library GNU LESSER GENERAL PUBLIC LICENSE v.3

Copyright CERN 2015
