using System;

namespace Server
{
    class BaseServiceEngine
    {
        public virtual void Compile(
            string _program,
            ref string _compilationOutput,
            ref bool _compilationPassed,
            ref bool _executionPassed,
            ref int _returnCode,
            ref string _executionOutput,
            ref string _sessionKey
        )
        {

        }
    }

    class InstanceServiceEngine:BaseServiceEngine
    {
        public override void Compile(
            string _program,
            ref string _compilationOutput,
            ref bool _compilationPassed,
            ref bool _executionPassed,
            ref int _returnCode,
            ref string _executionOutput,
            ref string _sessionKey
    )
        {
            // Генерация GUID-а
            _sessionKey = Guid.NewGuid().ToString();
            string sessionPath = FileSystemInspector.getSessionPath(_sessionKey);

            Compiler _compiler = new Compiler(sessionPath,_program);
            if (_compiler.Success)
            {
                _compilationPassed = true;
                _compilationOutput = _compiler.Output;
            }
        }
    }

    class ServiceEngine
    {
        private static BaseServiceEngine _instance = null;
        static ServiceEngine()
        {
            _instance = new InstanceServiceEngine();
        }

        public static void Compile(
            string _program, 
            ref string _compilationOutput, 
            ref bool _compilationPassed, 
            ref bool _executionPassed, 
            ref int _returnCode, 
            ref string _executionOutput, 
            ref string _sessionKey
        )
        {
            _instance.Compile(_program, ref _compilationOutput, ref _compilationPassed, ref _executionPassed, ref _returnCode, ref _executionOutput, ref _sessionKey);
        }
    }
}