#!/bin/bash
# Note: Make sure `default_md` is set to `sha256` in /etc/ssl/openssl.cnf.

function gen_cert() {
    CN=$1
    FILENAME=$2
    openssl genrsa -des3 -out $FILENAME.key 2048
    openssl rsa -in $FILENAME.key -out $FILENAME.key
    openssl req -new -nodes -key $FILENAME.key -out $FILENAME.csr -subj "/CN=$CN"
    openssl x509 -req -in $FILENAME.csr -days 365 -CA ca.crt -CAkey ca.key -CAcreateserial -out $FILENAME.crt
    rm $FILENAME.csr
}

# Clean up
rm *.crt *.key *.csr *.srl

# Generate the root (CA) certificate
openssl req -new -x509 -days 365 -nodes -out ca.crt -keyout ca.key -subj "/CN=root-ca"

echo "Generating leaf certificates"
gen_cert db server
gen_cert myapp client

openssl pkcs12 -export -inkey client.key -in client.crt -out client.pfx