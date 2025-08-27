# PowerShell script to generate PNG diagrams from PlantUML files
# Requires internet connection to use PlantUML web service

function ConvertTo-PlantUMLPNG {
    param(
        [string]$InputFile,
        [string]$OutputFile
    )
    
    Write-Host "Generating $OutputFile..." -ForegroundColor Yellow
    
    # Read the PlantUML content
    $content = Get-Content $InputFile -Raw
    
    # Convert to bytes and then to base64
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($content)
    $base64 = [System.Convert]::ToBase64String($bytes)
    
    # Simple URL encoding for base64 (basic characters)
    $encoded = $base64 -replace '\+', '%2B' -replace '/', '%2F' -replace '=', '%3D'
    
    # PlantUML web service URL
    $url = "http://www.plantuml.com/plantuml/png/$encoded"
    
    # Download the PNG image
    try {
        Invoke-WebRequest -Uri $url -OutFile $OutputFile -UseBasicParsing
        Write-Host "Successfully generated: $OutputFile" -ForegroundColor Green
    }
    catch {
        Write-Host "Error generating $OutputFile : $_" -ForegroundColor Red
    }
}

Write-Host "=== UML Class Diagram PNG Generation ===" -ForegroundColor Cyan
Write-Host "Generating comprehensive UML diagrams..." -ForegroundColor White

# Generate PNG files for all PlantUML class diagrams
ConvertTo-PlantUMLPNG -InputFile "UML_ClassDiagram.puml" -OutputFile "UML_ClassDiagram_Enhanced.png"
ConvertTo-PlantUMLPNG -InputFile "UML_AdapterPattern_Core.puml" -OutputFile "UML_AdapterPattern_Core.png"
ConvertTo-PlantUMLPNG -InputFile "UML_DetailedImplementation.puml" -OutputFile "UML_DetailedImplementation.png"

# Generate existing diagrams
ConvertTo-PlantUMLPNG -InputFile "UML_SequenceDiagram.puml" -OutputFile "UML_SequenceDiagram.png"
ConvertTo-PlantUMLPNG -InputFile "UML_AdapterPattern.puml" -OutputFile "UML_AdapterPattern.png"

Write-Host ""
Write-Host "=== Generation Summary ===" -ForegroundColor Cyan
Write-Host "Enhanced Class Diagram: UML_ClassDiagram_Enhanced.png" -ForegroundColor Green
Write-Host "Core Pattern Diagram: UML_AdapterPattern_Core.png" -ForegroundColor Green  
Write-Host "Detailed Implementation: UML_DetailedImplementation.png" -ForegroundColor Green
Write-Host "Sequence Diagram: UML_SequenceDiagram.png" -ForegroundColor Green
Write-Host "Pattern Structure: UML_AdapterPattern.png" -ForegroundColor Green
Write-Host ""
Write-Host "All UML diagrams generated successfully!" -ForegroundColor Cyan