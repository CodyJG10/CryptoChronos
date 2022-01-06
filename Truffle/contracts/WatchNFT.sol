//SPDX-License-Identifier: MIT
 
pragma solidity ^0.8.10;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721Enumerable.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "./Base/ERC2981PerToken.sol";

contract WatchNFT is ERC721URIStorage, ERC721Enumerable, Ownable, ERC2981PerTokenRoyalties {

    constructor() ERC721("Watches", "TIK") {}

    function _beforeTokenTransfer(address from, address to, uint256 tokenId)
        internal
        override(ERC721, ERC721Enumerable)
    {
        super._beforeTokenTransfer(from, to, tokenId);
    }

    function _burn(uint256 tokenId) internal override(ERC721, ERC721URIStorage) {
        super._burn(tokenId);
    }

    function _baseURI() internal view override returns (string memory) {
        return "https://ipfs.io/ipfs/";
    }

    function setTokenURI(uint256 tokenId, string memory _tokenURI) public onlyOwner {
        super._setTokenURI(tokenId, _tokenURI);
    }

    function tokenURI(uint256 tokenId)
        public
        view
        override(ERC721, ERC721URIStorage)
        returns (string memory)
    {
        return super.tokenURI(tokenId);
    }

    function supportsInterface(bytes4 interfaceId)
        public
        view
        override(ERC721, ERC721Enumerable, ERC2981Base)
        returns (bool)
    {
        return super.supportsInterface(interfaceId);
    }

    function safeMint(address to, uint256 tokenId, uint256 royaltyAmount, address royaltyRecipient) public onlyOwner {
        _safeMint(to, tokenId);
        _setTokenRoyalty(tokenId, royaltyRecipient, royaltyAmount);
    }

    function safeMintAndSetUri(address to, uint tokenId, string memory uri, uint256 royaltyAmount, address royaltyRecipient) public onlyOwner {
        _safeMint(to, tokenId);
        _setTokenURI(tokenId, uri);
        _setTokenRoyalty(tokenId, royaltyRecipient, royaltyAmount);
    }

}