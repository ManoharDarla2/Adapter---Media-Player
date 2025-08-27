# PowerShell script to generate PNG diagrams from PlantUML files
# Requires internet connection to use PlantUML web service

function ConvertTo-PlantUMLPNG {
    param(
        [string]$InputFile,
        [string]$OutputFile
    )
    
    # Read the PlantUML content
    $content = Get-Content $InputFile -Raw
    
    # Convert to bytes and then to base64
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($content)
    $base64 = [System.Convert]::ToBase64String($bytes)
    
    # URL encode the base64 string
    $encoded = [System.Web.HttpUtility]::UrlEncode($base64)
    
    # PlantUML web service URL
    $url = "http://www.plantuml.com/plantuml/png/$encoded"
    
    # Download the PNG image
    try {
        Invoke-WebRequest -Uri $url -OutFile $OutputFile
        Write-Host "Successfully generated: $OutputFile" -ForegroundColor Green
    }
    catch {
        Write-Host "Error generating $OutputFile : $_" -ForegroundColor Red
    }
}

# Generate PNG files for all PlantUML files
ConvertTo-PlantUMLPNG -InputFile "UML_ClassDiagram.puml" -OutputFile "UML_ClassDiagram.png"
ConvertTo-PlantUMLPNG -InputFile "UML_SequenceDiagram.puml" -OutputFile "UML_SequenceDiagram.png"
ConvertTo-PlantUMLPNG -InputFile "UML_AdapterPattern.puml" -OutputFile "UML_AdapterPattern.png"

Write-Host "PNG generation completed!" -ForegroundColor Cyan