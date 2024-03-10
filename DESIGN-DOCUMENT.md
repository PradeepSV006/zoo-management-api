# Zoo Management API - Design Document

This document outlines the design decisions and considerations for the Zoo Cost Calculator API.

## 1. API vs. Console Application

While the requirement could be implemented as a console application, this project is designed as an API to offer several benefits:

- **Ease of Testing:** The API allows for easier integration testing using tools like Swagger.
- **Scalability:** An API architecture can be readily scaled to accommodate additional functionality or integration with other systems.

## 2. Project Structure

The project follows a layered structure for better organization and maintainability:

- **Zoo.API:** This project contains the core API components, including controllers, a common exception filter, and service collection extensions.
  
- **Zoo.Common:** This project houses reusable components like configuration settings, custom exceptions, data access logic (data folder), DTOs, models, and constants.
  
- **Zoo.Core:** This project encapsulates the business logic within services.

In real-world scenarios, a separate project like Zoo.Data might exist to centralize all data access code. However, for this project, data access logic is contained within the Data folder of Zoo.Common.

### Data Files:

- **animals.csv** and **prices.txt:** These configuration files are stored within an internal config folder as they hold configuration data.
  
- **zoo.xml:** This file resides directly within the Data folder and contains data specific to the zoo.

The file paths are managed using appsettings.json, ConfigProvider, and IConfiguration. In production environments, consider storing file paths more securely, such as in a secrets vault.

## 3. Helper Classes

- **DataHelper.cs:** This class contains methods for reading and processing data files.
  
- **ParseHelper.cs:** This class provides utility functions to assist with parsing the data from the files.

## 4. Data Type Choice

For cost, food rate, and percentage calculations, decimal is chosen over double to ensure higher precision.

## 5. Unit Testing Focus

The unit tests primarily focus on the business logic within the services and less on the parsing code, assuming the data files follow a well-defined/srict format.

## 6. Potential Enhancements

Currently, the data files are read on every API call, which can be inefficient. To optimize performance:

- Implement a DataStore class with global properties to store processed data from files.
  
- During the first API call (or even during start up based on the need), process data from animals.csv and prices.txt and store them in DataStore.
  
- Subsequent calls can directly access data from DataStore, read zoo.xml, perform calculations, and return the response.

This optimization might not be necessary for a single zoo scenario but becomes relevant when dealing with multiple zoos with varying zoo.xml files while sharing the same configuration data (animals.csv and prices.txt).
