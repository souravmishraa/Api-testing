pipeline {
    agent any

    tools {
        dotnet 'dotnet-sdk-8.0' // Ensure Jenkins has this tool configured
    }

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
                junit '**/test_results.trx'
            }
        }
    }
}
