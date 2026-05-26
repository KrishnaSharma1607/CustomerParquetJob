# Customer Eligibility Parquet Pipeline using Azure Container Apps

## Project Overview

This project demonstrates an end-to-end cloud-based data processing pipeline that periodically extracts customer data from Azure SQL Database, transforms the data into Parquet format, and stores the generated output in Azure Blob Storage.

The solution is containerized using Docker, stored in Azure Container Registry (ACR), and executed through Azure Container App Jobs on a scheduled basis.

The project simulates a production-style batch processing workflow where scheduled jobs process data at regular intervals and store results for downstream analytics and data engineering use cases.

---

## Workflow / Pipeline Architecture

Azure SQL Database
↓
Read customer records
↓
Convert SQL rows into Customer objects
↓
Filter eligible customers
↓
Generate Parquet data in MemoryStream (RAM)
↓
Upload Parquet file to Azure Blob Storage
↓
Container execution completes
↓
Container resources are released automatically

---

## Technologies Used

* C#
* .NET
* SQL Server / Azure SQL Database
* Parquet.NET
* Docker
* Azure Blob Storage
* Azure Container Registry (ACR)
* Azure Container Apps Jobs (ACA)
* Azure Portal

---

## Key Features

* Reads customer data from Azure SQL Database
* Converts relational data into Parquet format
* Generates unique timestamp-based output files
* Uses in-memory processing through MemoryStream
* Avoids local file generation and local storage dependency
* Uploads generated files directly to Azure Blob Storage
* Containerized deployment using Docker
* Scheduled execution through Azure Container App Jobs
* Demonstrates cloud-native batch processing workflow

---

## Memory Optimization

Instead of creating temporary files on local storage, the project uses MemoryStream for in-memory Parquet generation.

Benefits:

* Eliminates temporary file storage
* Reduces disk I/O operations
* Faster processing
* Suitable for containerized environments
* Automatically releases memory after job completion

---
