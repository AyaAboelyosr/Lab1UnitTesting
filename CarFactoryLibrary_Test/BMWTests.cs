using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class BMWTests
    {
        [Fact]
        public void Equals_velocityAndDirection_true()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 0;
            bmw.drivingMode = DrivingMode.Backward;

            BMW bmw2 = new BMW();
            bmw2.velocity = 0;
            bmw2.drivingMode = DrivingMode.Backward;
            // Act
            bool result = bmw.Equals(bmw2);

            // Boolean Asserts
            Assert.True(result);
        }

        [Fact]
        public void InRange_VelocityAndDistance_True()
        {
            BMW bmw = new BMW();
            bmw.velocity = 2;

            double td = bmw.TimeToCoverDistance(20);
            Assert.InRange(td, 5, 20);

        }

        [Fact]
        public void NotInRange_VelocityAndDistance_True()
        {
            BMW bmw = new BMW();
            bmw.velocity = 2;

            double td = bmw.TimeToCoverDistance(20);
            Assert.NotInRange(td, 15, 20);

        }

        [Fact]
        public void Equal_Direction_Stopped_True()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Stopped;

            // Act
            string result = bmw.GetDirection();

            // string Asserts
            Assert.Equal(DrivingMode.Stopped.ToString(), result);

        }

        [Fact]
        public void Contains_Direction_Forward_True()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Forward;

            // Act
            string result = bmw.GetDirection();

            Assert.Contains("ar", result);

        }
        [Fact]
        public void EndsWith_Direction_Backward_True()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Backward;

            // Act
            string result = bmw.GetDirection();

            Assert.EndsWith("d", result);

        }
        [Fact]
        public void Matches_Direction_Stoped_True()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Stopped;

            // Act
            string result = bmw.GetDirection();

            Assert.Matches("^\\S*$", result);

        }

        [Fact]
        public void DoesNotMatch_Direction_Backward_True()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Backward;

            // Act
            string result = bmw.GetDirection();

            Assert.DoesNotMatch("^[Ff].*\r\n", result);


        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.Same(bmw, car);
            Assert.NotSame(bmw2, car);
        }


        [Fact]
        public void NewCar_CarTypeBMW_BMW_True()
        {
            Car? car = CarFactory.NewCar(CarTypes.BMW);
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
            Assert.IsNotType<Toyota>(car);

        }

        [Fact]
        public void NewCar_CarTypeHonda_Exception()
        {
            Assert.Throws<NotImplementedException>(() =>
            {

                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }


    }
}
