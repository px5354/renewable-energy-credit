import axios from 'axios';

const baseURL = 'https://renewableenergycredits.azurewebsites.net';
// http://localhost:43056

function buildCreateAssetForm(form) {
  return {
    Type: form.energyType,
  };
}

function buildIssueAmountForm(form) {
  return {
    AssetId: form.energyId,
    RecipientEmail: form.email,
    Amount: form.quantity,
  };
}

function buildTransferAssetForm(form) {
  return {
    RecipientEmail: form.recipientEmail,
    Amount: form.amount,
    AssetId: form.assetId,
    SenderEmail: form.senderEmail,
  };
}

export const createAsset = (form) => axios({
  method: 'post',
  baseURL: baseURL,
  url: 'api/tracker',
  data: buildCreateAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getAssets = () => axios({
  method: 'get',
  baseURL: baseURL,
  url: 'api/tracker/assets',
});

export const getAssetDetails = (assetId) => axios({
  method: 'get',
  baseURL: baseURL,
  url: `api/tracker/assets/issuedbatches/${assetId}`,
});

export const issueAmount = (form) => axios({
  method: 'post',
  baseURL: baseURL,
  url: 'api/tracker/assets/issue',
  data: buildIssueAmountForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const transferAmount = (form) => axios({
  method: 'post',
  baseURL: baseURL,
  url: 'api/tracker/wallet/transfer',
  data: buildTransferAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getTransactions = () => axios({
  method: 'get',
  baseURL: baseURL,
  url: 'api/tracker/transactions',
});

export const getBalances = () => axios({
  method: 'get',
  baseURL: baseURL,
  url: 'api/tracker/balances',
});

