pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/souravmishraa/Api-testing.git', branch: 'main'
            }
        }

        stage('Restore') {
            steps {
                dir('/home/knoldus/Api/RestSharpAPi') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('/home/knoldus/Api/RestSharpAPi') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('/home/knoldus/Api/RestSharpAPi') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                // Note: trx is not natively supported by the junit step
                // You need to convert it to JUnit XML or use a plugin
                echo 'TRX to JUnit conversion needed here if junit plugin is used'
                // junit '**/test_results.trx' // ❌ won't work as is
            }
        }
    }
}
