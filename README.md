# SEEDLING - EFA - Red Badge MVC Project
###### By Maggie Snader
#### Overview
###### &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seedling is a place where users can create a log that allows for tracking of various garden sites, and their plants. The system will also create a custom generated calendar showing planting dates to get everything started.
###### &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seedling is an ASP.NET MVC application with a heavy focus on n-tier architecture.
###### &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The database has three major tables, Location, Plant and Log Entry. All tables have full basic CRUD functionality. Location and Plant, as well as Plant and Log Entry each have a one to many relationship; one Location can have many Plants, and one Plant can have many Log Entries. The app also has a Calendar feature that will generate a custom calendar view that relates to the planting dates the user enters when creating a plant in the database.
