// pipeline {
//     agent any

//     tools {
//         dotnet 'dotnet-sdk-8.0' // Ensure Jenkins has this configured
//     }

//     stages {
//         stage('Checkout') {
//             steps {
//                 git url: 'https://github.com/souravmishraa/Api-testing.git', branch: 'main'
//             }
//         }

//         stage('Restore') {
//             steps {
//                 dir('/home/knoldus/Api/RestSharpAPi') {
//                     sh 'dotnet restore'
//                 }
//             }
//         }

//         stage('Build') {
//             steps {
//                 dir('/home/knoldus/Api/RestSharpAPi') {
//                     sh 'dotnet build --configuration Release'
//                 }
//             }
//         }

//         stage('Test') {
//             steps {
//                 dir('/home/knoldus/Api/RestSharpAPi') {
//                     sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
//                 }
//             }
//         }

//         stage('Publish Test Results') {
//             steps {
//                 junit '**/test_results.trx'
//             }
//         }
//     }
// }
// pipeline { 
//     agent any

//     stages {
//         stage('Checkout') {
//             steps {
//                 git url: 'https://github.com/souravmishraa/Api-testing.git', branch: 'main'
//             }
//         }

//         stage('Restore') {
//             steps {
//                 dir('RestSharpAPi') {
//                     sh 'dotnet restore'
//                 }
//             }
//         }

//         stage('Build') {
//             steps {
//                 dir('RestSharpAPi') {
//                     sh 'dotnet build --configuration Release'
//                 }
//             }
//         }

//         stage('Test') {
//             steps {
//                 dir('RestSharpAPi') {
//                     sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
//                 }
//             }
//         }

//         stage('Publish Test Results') {
//             steps {
//                 echo 'Note: TRX format not supported by junit step. Convert to XML if needed.'
//                 // If needed later: use trx2junit or similar tool
//             }
//         }
//     }
// }
pipeline { 
    agent any

    environment {
        RECIPIENTS = 'sourav.mishra@nashtechglobal.com'
    }

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
                echo 'Note: TRX format not supported by junit step. Convert to JUnit XML if needed.'
                // Optionally use trx2junit to convert .trx to .xml for better reporting
            }
        }
    }

    post {
        failure {
            emailext (
                subject: "🚨 Build Failed: ${env.JOB_NAME} #${env.BUILD_NUMBER}",
                body: """
                Build failed in Jenkins: ${env.JOB_NAME} #${env.BUILD_NUMBER}
                Check console output at: ${env.BUILD_URL}
                """,
                to: "${env.RECIPIENTS}"
            )
        }
    }
}
