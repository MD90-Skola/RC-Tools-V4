using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;

namespace Modern.Forms
{
    public static class FunctionCsgoRoll
    {
        public static async Task ApplyFilters(WebView2 webView)
        {
            string script = @"
                function triggerInputEvent(el){
                    el.dispatchEvent(new Event('input', { bubbles: true }));
                }

                function closeChat(){
                    const closeButton = document.querySelector('button.mat-focus-indicator.close.clip-bl.mat-icon-button.mat-button-base');
                    if (closeButton) closeButton.click();
                }

                function setPriceFilters(){
                    let maxPriceInput = document.querySelector('input[data-test=""max-price""]');
                    let minPriceInput = document.querySelector('input[data-test=""min-price""]');
                    
                    if(maxPriceInput){
                        maxPriceInput.value = '1500';
                        triggerInputEvent(maxPriceInput);
                    }

                    if(minPriceInput){
                        minPriceInput.value = '10';
                        triggerInputEvent(minPriceInput);
                    }
                }

                function clickMaxBalance(){
                    const maxButton = document.querySelector('button.mat-focus-indicator.fs-12.text-white.max-btn.text-capitalize.mat-flat-button.mat-button-base');
                    if (maxButton) maxButton.click();
                }

                async function selectBestDeals(){
                    // Öppna dropdown först
                    const dropdown = document.querySelector('mat-select');
                    if(dropdown){
                        dropdown.click();
                        await new Promise(r => setTimeout(r, 500)); // vänta dropdown laddning

                        const bestDealsOption = document.querySelector('mat-option#mat-option-3');
                        if (bestDealsOption && !bestDealsOption.classList.contains('mat-selected')){
                            bestDealsOption.click();
                        }

                        // klicka utanför för att stänga dropdown
                        document.body.click();
                    }
                }

                closeChat();
                setTimeout(() => {
                    setPriceFilters();
                    clickMaxBalance();
                    setTimeout(selectBestDeals, 1500);
                }, 1500);
            ";

            await webView.ExecuteScriptAsync(script);
        }
    }
}
