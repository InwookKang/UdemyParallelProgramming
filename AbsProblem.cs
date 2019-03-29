using System;
using System.Collections.Generic;

namespace ParallelProgramming
{
    public abstract class AbsProblem
    {
        private string mProblemName;
        private UserInput mUserInput = new UserInput();
        private string mDescription;

        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }

        public AbsProblem(string strProblemName)
        {
            mProblemName = strProblemName;
        }

        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public string GetDescription()
        {
            return mProblemName;
        }

        public bool RunAgain()
        {
            //New Line
            DisplayMessage("");
            DisplayMessage("Run Again? Enter 1 for Yes");

            bool bRunAgain = false;
            UserInput input = new UserInput();

            if (input.intUserInput() == 1)
            {
                bRunAgain = true;
            }

            return bRunAgain;
        }

        public int GetUserIntInput()
        {
            return mUserInput.intUserInput();
        }

        public int[] GetUserAryIntInput(int iSize)
        {
            return mUserInput.intAryUserInput(iSize);
        }

        public string[] GetUserAryStringInput()
        {
            string strInput = mUserInput.strUserInput();
            string[] straryReturn = strInput.Split(' ');

            return straryReturn;
        }

        public string GetUserStringInput()
        {
            return GetUserStringInput();
        }

        public void DisplayDescription()
        {
            Console.Write(this.Description);
        }

        public abstract void Begin();

    }

    internal interface IUserInput
    {
        int intUserInput();
        string strUserInput();
        int[] intAryUserInput(int iSize);
    }

    public class UserInput : IUserInput
    {
        /// <summary>
        /// Ints the user input.
        /// </summary>
        /// <returns>The user input.</returns>
        public int intUserInput()
        {
            DisplayMessage("Enter Number: ");
            int iReturn;
            Int32.TryParse(Console.ReadLine(), out iReturn);

            return iReturn;
        }

        /// <summary>
        /// Strings the user input.
        /// </summary>
        /// <returns>The user input.</returns>
        public string strUserInput()
        {
            DisplayMessage("Enter string: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Ints the ary user input.
        /// </summary>
        /// <returns>The ary user input.</returns>
        /// <param name="iSize">I size.</param>
        public int[] intAryUserInput(int iSize)
        {
            DisplayMessage("Enter Numbers seperated by [SPACE]");
            List<int> iListReturn = new List<int>();
            string strInput = Console.ReadLine();
            string[] strArray = strInput.Split(' ');

            foreach (string str in strArray)
            {
                Int32.TryParse(str, out int iNum);
                iListReturn.Add(iNum);
            }

            return iListReturn.ToArray();
        }

        /// <summary>
        /// Displaies the message.
        /// </summary>
        /// <param name="strMsg">String message.</param>
        private void DisplayMessage(string strMsg)
        {
            Console.WriteLine(strMsg);
        }
    }
}
