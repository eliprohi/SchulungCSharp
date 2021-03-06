﻿using SageAufbaukursCSharp.Services;
using System;
using System.IO;

namespace SageAufbaukursCSharp.ServiceImplementations
{
    public class SaveFileUtil : ISaveFileUtil
    {
        #region ISaveFileUtil        
        public Exception Fault { get; set; }
        public string Message { get; private set; }
        public bool Save(object beleg)
        {
            try
            {
                using (var sw = new StreamWriter(_fallbackPath))
                {
                    sw.Write("Hello World!");
                }
                
                return true;
            }
            catch (UnauthorizedAccessException uae)
            {
                Message = uae.Message;
                Fault = uae;
                return false;
            }
            catch (ArgumentException ae)
            {
                _fallbackPath = Path.Combine(Environment.GetEnvironmentVariables()["APPDATA"].ToString(), "beleg", ".txt");
                try
                {
                    using (var sw = new StreamWriter(_fallbackPath))
                    {
                        sw.Write("Hello World!");
                    }
                    _problemSolver.SetProblem(_fallbackPath);
                    Message = "FallbackPath wurde genutzt.";
                    return false;
                }
                catch (Exception)
                {
                    Fault = ae;
                    return false;
                }
            }
            catch(PathTooLongException pe)
            {
                var maxPathLength = 259;
                var fileName = Path.GetFileName(_fallbackPath);
                var fullPathLength = Path.GetFullPath(_fallbackPath).Length;
                
                if(fullPathLength > maxPathLength)
                {
                    var diff = fullPathLength - maxPathLength;
                    fileName.Substring(diff, fileName.Length - diff);
                    var editedPath = Path.GetPathRoot(_fallbackPath) + fileName;
                }

                try
                {
                    using (var sw = new StreamWriter(_fallbackPath))
                    {
                        sw.Write("Hello World!");
                    }
                    _problemSolver.SetProblem(_fallbackPath);
                    Message = "Filename wurde gekürzt!.";
                    return false;
                }
                catch (Exception)
                {
                    Fault = pe;
                    return false;
                }
            }
            catch (Exception e)
            {
                Fault = e;
                return false;
            }
        }

        public bool Save(object beleg, string FilePath)
        {
            throw new NotImplementedException();
        }
        #endregion ISaveFileUtil

        #region services
        private readonly IProblemSolver _problemSolver;
        #endregion services

        #region constructor
        public SaveFileUtil(IProblemSolver problemSolver ,string fallbackpath)
        {
            _problemSolver = problemSolver;
            _fallbackPath = fallbackpath;
        }
        #endregion constructor

        #region private fields
        private string _fallbackPath;
        #endregion private fields
    }
}
