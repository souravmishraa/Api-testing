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
                dir('RestSharpAPi') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('RestSharpAPi') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('RestSharpAPi') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'TRX to JUnit conversion needed if you want to use junit plugin.'
                // junit 'RestSharpAPi/**/test_results.trx' // only works if converted to JUnit XML
            }
        }
    }
}
