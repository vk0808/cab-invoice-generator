using NUnit.Framework;
using CabInvoiceGenerator;

namespace CanInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        // tc-1
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        // tc-2
        [Test]
        public void GivenMultipleRides_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, summary);
        }

        // tc-3
        [Test]
        public void GivenInvoiceGenerator_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, summary);
        }

        // tc-4
        [Test]
        public void GivenUserId_WhenInvoivceService_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("1241", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1241");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "1241");
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}