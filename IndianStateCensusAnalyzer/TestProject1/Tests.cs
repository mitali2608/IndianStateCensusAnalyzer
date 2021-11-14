using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace TestProject1
{
  
    public class Tests
    {
      
        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"E:\dotnet\IndianStateCensusAnalyzer\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"E:\dotnet\IndianStateCensusAnalyzer\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\WrongIndiaStateCode.csv";
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"E:\dotnet\IndianStateCensusAnalyzer\USCensusData.csv";
        static string wrongUSCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\USData.csv";
        static string wrongUSCensusFileType = @"E:\dotnet\IndianStateCensusAnalyzer\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"E:\dotnet\IndianStateCensusAnalyzer\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

    }


}