using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace IDvsGuid
{   
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class DataGeneratorBenchmarks {

        public static readonly string SmallPayload = "simple";

        public static readonly string MediumPayload = "rxgwkjzyxhyqddwvnkshwgyypvkkcmgmiiurljbrqfhancpttydrblujozxbxslnqkytlvasuliixywepvbbmufdcoitzhjaffuppqnkihqvhbsyesdizaxztcizicbnxbvfxyftbrgjiozxvnogedmxzqcwuudfzuutbtkclazcjxhdtbprwpjwhxbikfcphxkestbckkckcgsjdofsnxhigrwrowvtirlsdwzfclfiryefmufpoiqgmtrkdzmozzxsiehxpstsdvqhldaozakdryypaqxhzljecfzomsxgnbnmcpkrpxzwkhpxrnzppxaplahgpdvyvwwgyrfcxqwkcophziqyaxzyydccdxmiexarvtuegwusjbnfnuonxsljnmjomnbfvledigudtbimxrndzmpqfcuykcfustfwrhqvckktwwluztqgvgmldceysotuofgoxtmxweozdmepftoeopzgucjbicoxeefgkwcutqymraycsosvhlpeznxzzebakbidfzyxhvokztsbmxzgqmqzlghakktwhgswcdimmptoddvbebzdpynkyvyanwdfkzjletxrfdvxomqwtzolsawesnvnxhggivrvkgxcdkjttifjgktlvmfuobmbnchtmtsozguycelbertmrdxsjekozytoemjybdcngrvjpbfnqdwqgukycmcoygjhnomyyegsnjtsmahchafjdrscpyhbuqofbhiryzcsnnatkzjgypmbgslgqnjpynxwrkchrbxfjcadprchfazlotjulgnrvrhhowhprszzdofovgjbjlguxxpwlysiofoesgojubqrqeisttpkrymwhendcjzipllvxgeqxpqcqpnhzweonuuvgictefjjubptuzwfjglhqlkrzzvivvmatbqgqplaithjdcxmxmheybfajuhhkijaumrwjnqyrxxoskmhqyrjvmkjhbmlevovxgoseusslzsjcvzstypioxwybjfjkfybycinqcwi";
        public static readonly string BigPayload;

        private static readonly DataGenerator Generator = new DataGenerator();


        static DataGeneratorBenchmarks() 
        {
            BigPayload = File.ReadAllText(@"text_10240.txt");
        }

        // [Benchmark(Baseline = true)]
        // public void GenerateIds1000SmallPayload() 
        // {
        //     Generator.GenerateIdRecords(1000, SmallPayload);
        // }

        // [Benchmark]
        // public void GenerateGuids1000SmallPayload() 
        // {
        //     Generator.GenerateGuidRecords(1000, SmallPayload);
        // }

        // [Benchmark]
        // public void GenerateIds1000MediumPayload() 
        // {
        //     Generator.GenerateIdRecords(1000, MediumPayload);
        // }

        // [Benchmark]
        // public void GenerateGuids1000MediumPayload() 
        // {
        //     Generator.GenerateGuidRecords(1000, MediumPayload);
        // }

        // [Benchmark]
        // public void GenerateIds1000BigPayload() 
        // {
        //     Generator.GenerateIdRecords(1000, BigPayload);
        // }

        // [Benchmark]
        // public void GenerateGuids1000BigPayload() 
        // {
        //     Generator.GenerateGuidRecords(1000, BigPayload);
        // }


        [Benchmark(Baseline = true)]
        public void GenerateIds1000SmallPayload() 
        {
            Generator.GenerateIdRecords(1000, SmallPayload);
        }


        [Benchmark]
        public void GenerateIds1000SmallPayloadDapper() 
        {
            Generator.GenerateIdRecordsDapper(1000, SmallPayload);
        }


        [Benchmark]
        public void GenerateGuid1000SmallPayloadDapper() 
        {
            Generator.GenerateGuidRecordsDapper(1000, SmallPayload);
        }
        
        [Benchmark]
        public void GenerateIds1000SmallPayloadNPoco() 
        {
            Generator.GenerateIdRecordsNPoco(1000, SmallPayload);
        }

        [Benchmark]
        public void GenerateGuids1000SmallPayload() 
        {
            Generator.GenerateGuidRecords(1000, SmallPayload);
        }

        [Benchmark]
        public void GenerateGuids1000SmallPayloadNPoco() 
        {
            Generator.GenerateGuidRecordsNPoco(1000, SmallPayload);
        }

        
    }
}