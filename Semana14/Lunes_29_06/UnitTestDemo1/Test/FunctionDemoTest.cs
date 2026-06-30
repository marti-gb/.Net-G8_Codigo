namespace UnitTestDemo1.Test
{
    public static class FunctionDemoTest
    {
        public static void FunctionDemo_ReturnsPikachu_ReturnString()
        {
            try
            {
                //Arrange
                int num = 1;
                FunctionDemo functionDemo = new FunctionDemo();

                //Act
                string result = functionDemo.ReturnsPikachu(num);

                //Assert
                if(result == "PIKACHU")
                {
                    Console.WriteLine("PASSED: FunctionDemo_ReturnsPikachu_ReturnString");
                }
                else
                {
                    Console.WriteLine("FAILLED: FunctionDemo_ReturnsPikachu_ReturnString");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
