import axios from 'axios';

const azureUrl = 
'https://renewableenergycredits.azurewebsites.net';
// 'http://localhost:43056';

function buildCreateAssetForm(form) {
  return {
    Type: form.energyType,
  };
}

function buildIssueAmountForm(form) {
  return {
    AssetId: form.energyId,
    RecipientEmail: form.email,
    Amount: parseInt(form.quantity),
  };
}

function buildTransferAssetForm(form) {
  return {
    RecipientEmail: form.recipientEmail,
    Amount: parseInt(form.amount),
    AssetId: form.assetId,
    SenderEmail: form.senderEmail,
  };
}

export const createAsset = (form) => axios({
  method: 'post',
  baseURL: azureUrl,
  url: 'api/tracker',
  data: buildCreateAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getAssets = () => axios({
  method: 'get',
  baseURL: azureUrl,
  url: 'api/tracker/assets',
});

export const getAssetDetails = (assetId) => axios({
  method: 'get',
  baseURL: azureUrl,
  url: `api/tracker/assets/issuedbatches/${assetId}`,
});

export const issueAmount = (form) => axios({
  method: 'post',
  baseURL: azureUrl,
  url: 'api/tracker/assets/issue',
  data: buildIssueAmountForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const transferAmount = (form) => axios({
  method: 'post',
  baseURL: azureUrl,
  url: 'api/tracker/wallet/transfer',
  data: buildTransferAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getTransactions = () => axios({
  method: 'get',
  baseURL: azureUrl,
  url: 'api/tracker/transactions',
});

export const getBalances = () => axios({
  method: 'get',
  baseURL: azureUrl,
  url: 'api/tracker/balances',
});

