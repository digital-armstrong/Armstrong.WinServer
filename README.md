# Armstrong windows Server
An open-source windows serverfor ARMStrong 

* [ARMStrong server with GUI](#armstrong-server-with-gui)
    * [General](#general)
    * [Connection](#connection)
    * [What can he do?](#what-can-he-do)
    * [Get started](#get-started)

## ARMStrong server with GUI
![Armstrong main window and graphic](https://user-images.githubusercontent.com/46975515/152937954-b1096ed0-a5ee-4dc7-bdfc-39949ed18b0f.png)

### General
[__Armstrong__](https://github.com/owlscatcher/Armstrong) - Automated Radioactive Monitoring System that includes, in a simple case, 3 nodes:
- Ionizing radiation detection block (_for example: [BDMG-08R-04](http://pzi.ru/bdmg_08r_345.htm)_);
- The communication and control channel is based on ATmega16, the firmware for which will be [here](https://github.com/owlscatcher/Armstrong);
- A server for collecting, storing, converting and displaying information, which also performs the role of `MASTER` and manages all detection blocks through communication channels.

### Connection
Communication with the detection units is carried out via a twisted pair, via the RS-485 protocol. The server with the application acts as the `MASTER`, and communication channels act as the `SLAVE`.

All control packages are [described here](https://docs.google.com/spreadsheets/d/1cVXABW_TIEeYiJJf-rI0SjuYpnwkBZHMOtcAaCQZt2U).

### What can he do?
- Performs manual and automatic control of detection blocks;
- Conducts continuous polling of detection blocks;
- Converts the measurement result into system and non-system units of measurement (Sievert, Becquerel, Curie, Roentgen);
- Saves the measurement history in the database;
- Displays current measurement results;
- Controls the alarm system;
- Builds graphs;
- Calculates the emission of gases.

### Get started
- Create database and tables. You can use [SQL-script](https://github.com/owlscatcher/Armstrong/tree/master/tools/sql_scripts), or follow the structure described in the "Database Structure" section;
- Connect the RS-485 to USB converter to the server (I used [ОВЕН-АС4m](https://owen.ru/product/as4m));
- Connect your RS-485 communication line to the converter.
- Before the first launch, specify in the settings the ConnectionString for the database and the ComPort-name(_usually its name is СOM3-COM99_) to which the RS-485 to USB converter is connected.
- Be cool!
